﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Domain.Interfaces;
internal interface IPaymentRepository: IRepository<Payment>
{
    DbSet<Payment> Payments { get; }
}