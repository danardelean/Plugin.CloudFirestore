﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Plugin.CloudFirestore
{
    public interface ICollectionReference : IQuery
    {
        string Id { get; }
        string Path { get; }
        IDocumentReference Parent { get; }
        IDocumentReference GetDocument(string documentPath);
        void AddDocument<T>(T data, CompletionHandler handler) where T : class;
        Task AddDocumentAsync<T>(T data) where T : class;
    }
}
