﻿using Restaurants.Domain.Repositories;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Restaurants.Infrastructure.Repositories
{
    internal class RestaurantsRepository(RestaurantDbContext dbContext) : IRestaurantsRepository
    {
        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var restaurants = await dbContext.Restaurants.ToListAsync();
            return restaurants;
        }
    }
}
