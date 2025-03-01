﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SampleREST.Services.ModelEF;

public partial class OrderDetail
{
    [Key]
    public int OrderDetailId { get; set; }

    [Required]
    [StringLength(8)]
    [Unicode(false)]
    public string OrderHeaderId { get; set; }

    public int ProductId { get; set; }

    public int Qty { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    [ForeignKey("OrderHeaderId")]
    [InverseProperty("OrderDetails")]
    public virtual OrderHeader OrderHeader { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("OrderDetails")]
    public virtual Product Product { get; set; }
}