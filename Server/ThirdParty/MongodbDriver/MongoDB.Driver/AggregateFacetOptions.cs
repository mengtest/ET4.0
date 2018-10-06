﻿/* Copyright 2016 MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using MongoDB.Bson.Serialization;

namespace MongoDB.Driver
{
    /// <summary>
    /// Options for the aggregate $facet stage.
    /// </summary>
    /// <typeparam name="TOutput">The type of the output documents.</typeparam>
    public sealed class AggregateFacetOptions<TOutput>
    {
        private IBsonSerializer<TOutput> _outputSerializer;

        /// <summary>
        /// Gets or sets the output serializer.
        /// </summary>
        public IBsonSerializer<TOutput> OutputSerializer
        {
            get { return _outputSerializer; }
            set { _outputSerializer = value; }
        }
    }
}
