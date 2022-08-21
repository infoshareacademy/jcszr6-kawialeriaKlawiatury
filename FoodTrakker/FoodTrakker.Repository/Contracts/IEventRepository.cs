﻿using FoodTrakker.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.Repository.Contracts
{
    public interface IEventRepository : IRepository<Event>
    {
        public Task<List<Event>> GetFullEventInfoAsync();
        public Task<Event> GetFullEventInfoAsync(int Id);
    }
}
