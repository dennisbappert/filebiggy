﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileBiggy.Contracts;

namespace FileBiggy.Common
{
    public abstract class StoreBase<T> : IBiggyStore<T>, IAsyncBiggyStore<T>
    {
        protected Dictionary<string, string> ConnectionString { get; private set; }

        public StoreBase(
            Dictionary<string, string> connectionString
            )
        {
            ConnectionString = connectionString;
        }

        protected virtual string DatabaseName
        {
            get
            {
                var thingyType = GetType().GenericTypeArguments.Single().Name;
                return Inflector.Inflector.Pluralize(thingyType).ToLower();
            }
        }

        protected virtual object GetKey(T item)
        {
            var identity = item.GetKeyFromEntity();
            return identity ?? item.GetHashCode();
        }

        public abstract T Find(object id);
        public abstract List<T> All();
        public abstract void Clear();
        public abstract void Add(T item);
        public abstract void Add(IEnumerable<T> items);
        public abstract T Update(T item);
        public abstract void Remove(T item);
        public abstract void Remove(IEnumerable<T> items);

        public abstract Task<List<T>> AllAsync();
        public abstract Task ClearAsync();
        public abstract Task AddAsync(T item);
        public abstract Task AddAsync(IEnumerable<T> items);
        public abstract Task<T> UpdateAsync(T item);
        public abstract Task RemoveAsync(T item);
        public abstract Task RemoveAsync(IEnumerable<T> items);
        public abstract IQueryable<T> AsQueryable();
    }
}