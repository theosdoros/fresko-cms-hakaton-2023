﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fresko_BE.Data.TableModels
{
    [Table("image_picker")]
    public class ImagePicker
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int id { get; set; }
        [Required, StringLength(255), DataType(DataType.Text)]
        public string absolute_path { get; set; }
        [Required, StringLength(255), DataType(DataType.Html)]
        public string description { get; set; }
        [Required]
        public int position { get; set; }
        [Required]
        public DateTime cretion_date { get; set; }

        public Page page { get; set; }


        private AllComponents content_type = new AllComponents();
    }
}