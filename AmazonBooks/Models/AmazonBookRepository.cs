﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonBooks.Models
{
    public interface AmazonBookRepository 
    {
        IQueryable<Book> Books { get; }
    }
}
