using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public partial class Department : GeneralLocalizableEntity
    {
        public Department()
        {
            Students = new HashSet<Student>();

            DepartmentSubjects = new HashSet<DepartmentSubject>();

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }
        [StringLength(200)]
        public string DNameAr { get; set; }
        [StringLength(200)]
        public string DNameEn { get; set; }
        [InverseProperty(nameof(Student.Department))]

        public int? InsMangerId { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<Student>? Students { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<DepartmentSubject>? DepartmentSubjects { get; set; }
        [InverseProperty("department")]
        public virtual ICollection<Instructor>? Instructors { get; set; }
        [ForeignKey("InsMangerId")]
        [InverseProperty("DepartmentManager")]
        public virtual Instructor? Instructor { get; set; }
    }
}
