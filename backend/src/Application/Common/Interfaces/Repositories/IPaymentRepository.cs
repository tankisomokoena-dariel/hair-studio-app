﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Application.Common.Interfaces.Repositories;
internal interface IPaymentRepository : IRepository<Payment>
{
}