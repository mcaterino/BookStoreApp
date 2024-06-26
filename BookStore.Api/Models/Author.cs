﻿using System;
using System.Collections.Generic;

namespace BookStore.Api.Models;

public partial class Author
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Bio { get; set; }
    public virtual ICollection<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();
}