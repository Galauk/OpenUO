﻿#region License Header

// /***************************************************************************
//  *   Copyright (c) 2011 OpenUO Software Team.
//  *   All Right Reserved.
//  *
//  *   ArtworkFactory.cs
//  *
//  *   This program is free software; you can redistribute it and/or modify
//  *   it under the terms of the GNU General Public License as published by
//  *   the Free Software Foundation; either version 3 of the License, or
//  *   (at your option) any later version.
//  ***************************************************************************/

#endregion

#region Usings

using System.Threading.Tasks;

using OpenUO.Core.Patterns;
using OpenUO.Ultima.Adapters;

#endregion

namespace OpenUO.Ultima
{
    public class ArtworkFactory : AdapterFactoryBase
    {
        public ArtworkFactory(InstallLocation install, IContainer container)
            : base(install, container)
        {
        }

        public int GetLandTileCount<T>()
        {
            return 0x4000;
        }

        public int GetStaticTileCount<T>()
        {
            return GetAdapter<IArtworkStorageAdapter<T>>().Length - 0x4000;
        }

        public T GetLand<T>(int index)
        {
            return GetAdapter<IArtworkStorageAdapter<T>>().GetLand(index);
        }

        public T GetStatic<T>(int index)
        {
            return GetAdapter<IArtworkStorageAdapter<T>>().GetStatic(index);
        }

        public Task<int> GetStaticTileCountAsync<T>()
        {
            return Task.Run(async () =>
            {
                var adapter = await GetAdapterAsync<IArtworkStorageAdapter<T>>().ConfigureAwait(false);

                return adapter.Length - 0x4000;
            });
        }

        public Task<T> GetLandAsync<T>(int index)
        {
            return Task.Run(async () =>
            {
                var adapter = await GetAdapterAsync<IArtworkStorageAdapter<T>>().ConfigureAwait(false);

                return await adapter.GetLandAsync(index).ConfigureAwait(false);
            });
        }

        public Task<T> GetStaticAsync<T>(int index)
        {
            return Task.Run(async () =>
            {
                var adapter = await GetAdapterAsync<IArtworkStorageAdapter<T>>().ConfigureAwait(false);

                return await adapter.GetStaticAsync(index).ConfigureAwait(false);
            });
        }
    }
}