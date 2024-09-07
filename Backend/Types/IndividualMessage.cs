using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medfar.Interview.Types
{
    public class IndividualMessage
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public Guid? LastUpdatedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? ArchivalDate { get; set; }
        public Guid? ArchivedBy { get; set; }
        public string Subject{ get; set; }
        public string Body { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsTask{ get; set; }
        public DateTime? StartDate{ get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsDraft { get; set; }
        public bool? IsGroupTask { get; set; }
        public Guid? DocumentPatientId { get; set; }
        public string FileName{ get; set; }
        public Guid? TypeTaskLookupId { get; set; }
        public Guid? PriorityLookupId { get; set; }
        public Guid FromContactId { get; set; }

    }
}
