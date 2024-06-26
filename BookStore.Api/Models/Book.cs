﻿using System;
using System.Collections.Generic;

namespace BookStore.Api.Models;

public partial class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int? Year { get; set; }
    public string Isbn { get; set; } = null!;
    public string? Summary { get; set; }
    public string? Image { get; set; }
    public decimal? Price { get; set; }
    public virtual ICollection<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();
}
