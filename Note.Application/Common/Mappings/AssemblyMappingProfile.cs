using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Notes.Application.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly) =>
            ApplyMappigsFromAssembly(assembly);
        /// <summary>
        /// Применить маппинг из сборки
        /// </summary>
        /// <param name="assembly"></param>
        private void ApplyMappigsFromAssembly(Assembly assembly)
        {
            // Сканируем сборку и найти любые типы, реализующие интерфейс IMapWith
            var types = assembly.GetExportedTypes() // Получает открытые типы, определенные в этой сборке и видимые за ее пределами
                .Where(type => type.GetInterfaces() // Возвращает все интерфейсы, реализуемые или наследуемые текущим объектом Type
                .Any(i => i.IsGenericType && // Является универсальным (Generic)
                i.GetGenericTypeDefinition() == typeof(IMapWith<>))) // Объект Type, представляющий универсальный тип, на основе которого можно сконструировать текущий тип
                                                                     // и экземпляр System.Type для указанного типа
                .ToList();

            foreach (var type in types)
            {
                // Создает экземпляр указанного типа, используя конструктор этого типа без параметров.
                var instance = Activator.CreateInstance(type);
                // Получаем по имени заданный метод текущего класса Type
                var methodInfo = type.GetMethod("Mapping");

                // Вызовем метод Mspping из отнаследованного типа
                // или из интерфейса, если тип не реализует этот метод
                methodInfo?.Invoke(instance, new object[] { this });
            }    
        }
    }
}
