using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BeautySalon.Auth.Models;
using BeautySalon.Models.Materials;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.Models
{
    [Table(name:"employee",Schema ="public")]
    public class Employee
    {
        [Column("employee_id")]
        [Key]
        public int EmployeeId { get; set; }
        [Column("surname")]
        [Required]
        [StringLength(50, ErrorMessage = "Длина поля не должна превышать 50 символов")]
        public string Surname { get; set; }
        [Column("firstname")]
        [Required]
        [StringLength(50, ErrorMessage = "Длина поля не должна превышать 50 символов")]
        public string Firstname { get; set; }
        [Column("patronymic")]
        [StringLength(50, ErrorMessage = "Длина поля не должна превышать 50 символов")]
        public string Patronymic { get; set; }
        [Column("date_birth")]
        public DateTime DateBirth { get; set; }
        [Column("specialization_id")]
        [ForeignKey(nameof(Specialization))]
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        [Column("phone_number")]
        [Required]
        [StringLength(30, ErrorMessage = "Длина поля не должна превышать 30 символов")]
        public string PhoneNumber { get; set; }
        [Column("address")]
        [Required]
        [StringLength(200, ErrorMessage = "Длина поля не должна превышать 200 символов")]
        public string Address { get; set; }
        [Column("note")]
        [StringLength(200, ErrorMessage = "Длина поля не должна превышать 200 символов")]
        public string? Note { get; set; }
        [Column("photo")]
        public byte[] Photo { get; set; }

        public User? User { get; set; }

        [NotMapped]
        public string GetPhotoInBase64String
        {
            get
            {
                if (Photo != null)
                    return Convert.ToBase64String(Photo);
                else
                    return String.Empty;
            }
        }

        [NotMapped]
        public string FullName 
        {
            get 
            {
                return $"{Surname} {Firstname} {Patronymic}";
            }
        }

        

        public ICollection<Record> Records { get; set; } = new List<Record>();
        public ICollection<ReportCard> ReportCards { get; set; } = new List<ReportCard>();
        public ICollection<Expenditure> Expenditures { get; set; } = new List<Expenditure>();
        public ICollection<EmployeeCategory> EmployeeCategories { get; set; } = new List<EmployeeCategory>();
        public ICollection<CategoryService> CategoryServices { get; set; } = new List<CategoryService>();



    }
}
