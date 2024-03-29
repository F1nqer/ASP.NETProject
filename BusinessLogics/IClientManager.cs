﻿using DbModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
        List<ClientProfile> GetAll();
        ClientProfile Get(string Id);
    }
}
