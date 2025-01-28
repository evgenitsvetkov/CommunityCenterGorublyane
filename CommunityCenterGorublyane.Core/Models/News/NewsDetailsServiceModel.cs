﻿using System.ComponentModel.DataAnnotations;
using static CommunityCenterGorublyane.Core.Constants.MessageConstants;
using static CommunityCenterGorublyane.Infrastructure.Constants.DataConstants;

namespace CommunityCenterGorublyane.Core.Models.News
{
    public class NewsDetailsServiceModel : NewsServiceModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ContentMaxLength,
           MinimumLength = ContentMinLength,
           ErrorMessage = LengthMessage)]
        [Display(Name = "Описание")]
        public string Content { get; set; } = string.Empty;

        public IEnumerable<NewsCommentServiceModel> Comments { get; set; } = new List<NewsCommentServiceModel>();
    }
}
