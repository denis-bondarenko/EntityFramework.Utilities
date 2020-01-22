﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace EntityFramework.Utilities
{
    public interface IQueryProvider
    {
        bool CanDelete { get; }
        bool CanUpdate { get; }
        bool CanInsert { get; }
        bool CanBulkUpdate { get; }

        string GetDeleteQuery(QueryInformation queryInformation);
        string GetUpdateQuery(QueryInformation predicateQueryInfo, QueryInformation modificationQueryInfo);
        void InsertItems<T>(IEnumerable<T> items, string schema, string tableName, IList<ColumnMapping> properties, DbConnection storeConnection, int? bulkCopyTimeout, int? batchSize);
        void InsertItemsWithCheckConstraintsOn<T>(IEnumerable<T> items, string schema, string tableName, IList<ColumnMapping> properties, DbConnection storeConnection, int? bulkCopyTimeout, int? batchSize);
        void UpdateItems<T>(IEnumerable<T> items, string schema, string tableName, IList<ColumnMapping> properties, DbConnection storeConnection, int? bulkCopyTimeout, int? batchSize, UpdateSpecification<T> updateSpecification);
        void UpdateItemsWithCheckConstraintsOn<T>(IEnumerable<T> items, string schema, string tableName, IList<ColumnMapping> properties, DbConnection storeConnection, int? bulkCopyTimeout, int? batchSize, UpdateSpecification<T> updateSpecification);

        bool CanHandle(DbConnection storeConnection);


        QueryInformation GetQueryInformation<T>(System.Data.Entity.Core.Objects.ObjectQuery<T> query);


    }
}
