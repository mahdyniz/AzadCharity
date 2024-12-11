﻿using AzadCharity.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzadCharity.DAL.Repositories
{
    public interface IUnitOfWork
    {
        ICharityCaseRepository CharityCase{ get; }

        void SaveAsync();
    }
}