using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project_v._2.Models
{
    public class register
    {
        [BsonId]
        public string _id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        [Display(Name = "UserName")]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 4)]
        [Display(Name = "PassWord")]
        public string password { get; set; }

        [Display(Name = "ชื่อ-นามสกุล")]
        [StringLength(150)]
        public string name { get; set; }

        [Display(Name = "รูปภาพงานที่ 1")]
        public string pictruejob1 { get; set; }

        [Display(Name = "รูปภาพงานที่ 2")]
        public string pictruejob2 { get; set; }

        [Display(Name = "รูปภาพงานที่ 3")]
        public string pictruejob3 { get; set; }

        [Display(Name = "ชื่องาน")]
        [StringLength(150)]
        public string namejob { get; set; }

        [Display(Name = "รายละเอียดงาน")]
        [StringLength(250)]
        public string detail { get; set; }

        [Display(Name = "สถานที่")]
        public string address { get; set; }

        [Display(Name = "ราคางาน")]
        public string price { get; set; }

        [Display(Name = "เบอร์โทรศัพท์")]
        public string phone { get; set; }

        [Display(Name = "ID line")]
        public string line { get; set; }
        
    }
}
