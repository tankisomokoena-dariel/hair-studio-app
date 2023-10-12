﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Domain.Interfaces;
public interface IReviewRepository : IRepository<Review>
{
    DbSet<Review> Reviews { get; }
}
