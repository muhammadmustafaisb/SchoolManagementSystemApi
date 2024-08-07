﻿using System.ComponentModel.DataAnnotations;

namespace SMSApi.Core.Dto.TeacherDto
{
    public class TeacherCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Number { get; set; }
    }
}
