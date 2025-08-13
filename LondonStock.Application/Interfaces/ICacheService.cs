﻿namespace LondonStock.Application.Interfaces
{
    public interface ICacheService
    {
        T? Get<T>(string key);
        void Set<T>(string key, T value, TimeSpan expiry);
        void Remove(string key);
    }
}
