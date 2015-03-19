using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using Resgrid.Model;

namespace Resgrid.Repository
{
	/// <summary>
	/// The base repository implemenation.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class RepositoryBase<T> : IDisposable, IRepository<T> where T : class, IEntity
	{
		/* 
		 * <KeithStyleNovella> 
		 * 
		 * Originally this repo used IDbContext
		 * and IDbSet for entity and context control. This worked great, until
		 * multiple long lasting contexts and other systems all were changing the
		 * same underlying database. There was no way using IDbContext and IDbSet
		 * to force a refresh of the L2 ORM cache that EntityFramework's context
		 * or DbSet were holding on to.
		 * 
		 * So changing to ObjectContext and ObjectSet allowed the setting of the
		 * MergeOption.OverwriteChanges on the set, which will always pick up 
		 * changes from the backing store.
		 * 
		 * </KeithStyleNovella>
		 */
		protected ObjectContext context;
		protected ObjectSet<T> entities;

		public RepositoryBase(IDbContext context)
		{
			this.context = ((IObjectContextAdapter)context).ObjectContext;
			ObjectSet<T> set = this.context.CreateObjectSet<T>();

			// This allows the repo to always get the latest data from the database instead of L2 ORM Cache
			if (Properties.Settings.Default.DisableL2ORMCache)
				set.MergeOption = MergeOption.OverwriteChanges;

			if (!context.IsSqlCe())
				this.context.CommandTimeout = 300;

			entities = set;

			// Uncomment the below if you want to see EF debuggin information Do not deploy to prod!
			//this.context.ObjectStateManager.ObjectStateManagerChanged += (sender, e) =>
			//{
			//	Trace.WriteLine(string.Format("{0}, {1}", e.Action, e.Element));
			//};
		}

		public virtual IQueryable<T> GetAll()
		{
			return entities;
		}

		public virtual void SaveOrUpdate(T entity)
		{
			//This repository supports Guid and Int based ID's. If you need to support other types add them here.
			if ((entity.Id is Guid && ((Guid)entity.Id) == Guid.Empty) ||
				(entity.Id is int && ((int)entity.Id) == 0))
			{
				entities.AddObject(entity);
			}

			context.SaveChanges();
		}

		public async virtual void SaveOrUpdateAsync(T entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			if ((entity.Id is Guid && ((Guid)entity.Id) == Guid.Empty) ||
				(entity.Id is int && ((int)entity.Id) == 0))
			{
				entities.AddObject(entity);
			}

			await context.SaveChangesAsync(cancellationToken);
		}

		public virtual void Delete(T entity)
		{
			entities.DeleteObject(entity);
			context.SaveChanges();
		}

		public async virtual void DeleteAsync(T entity, CancellationToken cancellationToken = default(CancellationToken))
		{
			entities.DeleteObject(entity);
			await context.SaveChangesAsync(cancellationToken);
		}

		public virtual void DeleteAll(IEnumerable<T> entitesToDelete)
		{
			foreach (var entity in entitesToDelete)
				entities.DeleteObject(entity);

			context.SaveChanges();
		}

		public async virtual void DeleteAllAsync(IEnumerable<T> entitesToDelete, CancellationToken cancellationToken = default(CancellationToken))
		{
			foreach (var entity in entitesToDelete)
				entities.DeleteObject(entity);

			await context.SaveChangesAsync(cancellationToken);
		}

		public virtual void SaveOrUpdateAll(IEnumerable<T> entitiesToAdd)
		{
			foreach (var entity in entitiesToAdd)
			{
				if ((entity.Id is Guid && ((Guid)entity.Id) == Guid.Empty) ||
				(entity.Id is int && ((int)entity.Id) == 0))
				{
					entities.AddObject(entity);
				}
			}

			context.SaveChanges();
		}

		public async virtual void SaveOrUpdateAllAsync(IEnumerable<T> entitiesToAdd, CancellationToken cancellationToken = default(CancellationToken))
		{
			foreach (var entity in entitiesToAdd)
			{
				//This repository supports Guid and Int based ID's. If you need to support other types add them here.
				if ((entity.Id is Guid && ((Guid)entity.Id) == Guid.Empty) ||
				(entity.Id is int && ((int)entity.Id) == 0))
				{
					entities.AddObject(entity);
				}
			}

			await context.SaveChangesAsync(cancellationToken);
		}

		public void Dispose()
		{
			if (context != null)
			{
				context.Dispose();
				context = null;
			}

			entities = null;
		}
	}
}
