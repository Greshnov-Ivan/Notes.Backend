using AutoMapper;
namespace Notes.Application.Common.Mappings
{
    public interface IMapWith<T>
    {
        /// <summary>
        /// Создать конфигурацию из исходного типа
        /// </summary>
        /// <param name="profile"></param>
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
