﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApi.Data.Models;
public class TodoItemModel
{
    [Key]
    public int ItemId { get; set; }

    [Required(ErrorMessage = "ItemName is required")]
    [Column(TypeName = "nvarchar(100)")]
    public string ItemName { get; set; }

    [Required(ErrorMessage = "ItemDescription is required")]
    [Column(TypeName = "nvarchar(100)")]
    public string ItemDescription { get; set; }

    [Required(ErrorMessage = "ItemStatus is required")]
    [Column(TypeName = "bit")]
    public bool ItemStatus { get; set; }
}
