/*
 * Copyright (c) 2018 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 * 
 * https://github.com/piranhacms/piranha.core
 * 
 */

using System;
using System.Collections.Generic;

namespace Piranha.Services
{
    public interface IContentService<TContent, TField, TModelBase> : IRegionService
        where TContent : Data.Content<TField> 
        where TField : Data.ContentField
        where TModelBase : Models.Content
    {
        /// <summary>
        /// Creates a new content model of the given type.
        /// </summary>
        /// <param name="contentType">The content type</param>
        /// <returns>The model</returns>
        T Create<T>(Models.ContentType contentType) where T : Models.Content;

        /// <summary>
        /// Creates a new block.
        /// </summary>
        /// <param name="typeName">The typename</param>
        /// <returns>The block</returns>
        object CreateBlock(string typeName);

        /// <summary>
        /// Transforms the given data into a new model.
        /// </summary>
        /// <typeparam name="T">The model type</typeparam>
        /// <param name="content">The content entity</param>
        /// <param name="type">The content type</param>
        /// <returns>The page model</returns>
        T Transform<T>(TContent content, Models.ContentType type, Action<TContent, T> process = null) 
            where T : Models.Content, TModelBase;

        /// <summary>
        /// Transforms the given model into content data.
        /// </summary>
        /// <param name="model">The model</param>
        /// <param name="type">The conten type</param>
        /// <param name="dest">The optional dest object</param>
        /// <returns>The content data</returns>
        TContent Transform<T>(T model, Models.ContentType type, TContent dest = null)
            where T : Models.Content, TModelBase;

        /// <summary>
        /// Transforms the given block data into block models.
        /// </summary>
        /// <param name="blocks">The data</param>
        /// <returns>The transformed blocks</returns>
        IList<Extend.Block> TransformBlocks(IEnumerable<Data.Block> blocks);

        /// <summary>
        /// Transforms the given block data into block models.
        /// </summary>
        /// <param name="blocks">The data</param>
        /// <typeparam name="T">The block types</typeparam>
        /// <returns>The transformed blocks</returns>
        IList<Extend.Block> TransformBlocks<T>(IEnumerable<T> blocks) where T : Data.IContentBlock;

        /// <summary>
        /// Transforms the given blocks to the internal data model.
        /// </summary>
        /// <param name="models">The blocks</param>
        /// <returns>The data model</returns>
        IList<Data.Block> TransformBlocks(IList<Extend.Block> models);

        /// <summary>
        /// Transforms the given blocks to the internal data model.
        /// </summary>
        /// <param name="models">The blocks</param>
        /// <typeparam name="T">The data type</typeparam>
        /// <returns>The data model</returns>
        IList<T> TransformBlocks<T>(IList<Extend.Block> models) where T : Data.IContentBlock;        
    }
}
