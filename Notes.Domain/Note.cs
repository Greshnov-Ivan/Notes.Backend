using System;

namespace Notes.Domain
{
    public class Note
    {
        /// <summary>
        /// Owner
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Title note
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Content note
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Date of creation
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Date edit
        /// </summary>
        public DateTime? EditDate { get; set; }
    }
}
