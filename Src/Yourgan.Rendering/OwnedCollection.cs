/*
Yourgan
Copyright (C) 2009  Ertan Tike

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Yourgan.Rendering
{
    public class OwnedCollection<T> : System.Collections.ObjectModel.Collection<T>
    {
        public void AddRange(IEnumerable<T> collection)
        {
            this.InsertRange(base.Count, collection);
        }

        public ReadOnlyCollection<T> AsReadOnly()
        {
            return new ReadOnlyCollection<T>(base.Items);
        }

        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            ((List<T>)base.Items).CopyTo(index, array, arrayIndex, count);
        }
        protected sealed override void InsertItem(int index, T item)
        {
            this.InsertItems(index, new T[] { item });
        }

        protected virtual void InsertItems(int index, IEnumerable<T> collection)
        {
            ((List<T>)base.Items).InsertRange(index, collection);
        }

        public void InsertRange(int index, IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            this.InsertItems(index, collection);
        }

        public void Move(T value, int newIndex)
        {
            int index = base.IndexOf(value);

            if (index == -1)
            {
                throw new ArgumentException("value not located in the collection !");
            }

            this.Move(index, newIndex);
        }

        public void Move(int oldIndex, int newIndex)
        {
            if ((oldIndex < 0) || (oldIndex >= base.Count))
            {
                throw new ArgumentOutOfRangeException("oldIndex");
            }

            if ((newIndex < 0) || (newIndex >= base.Count))
            {
                throw new ArgumentOutOfRangeException("newIndex");
            }

            this.MoveItem(oldIndex, newIndex);
        }

        protected virtual void MoveItem(int oldIndex, int newIndex)
        {
            T item = base.Items[oldIndex];

            ((List<T>)base.Items).RemoveAt(oldIndex);

            ((List<T>)base.Items).Insert(Math.Min(newIndex, base.Count), item);
        }

        protected sealed override void RemoveItem(int index)
        {
            this.RemoveItems(index, 1);
        }

        protected virtual void RemoveItems(int index, int count)
        {
            ((List<T>)base.Items).RemoveRange(index, count);
        }

        public void RemoveRange(int index, int count)
        {
            if ((index < 0) || (count < 0))
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if ((base.Count - index) < count)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            if (count != 0)
            {
                this.RemoveItems(index, count);
            }
        }

        public void Sort()
        {
            this.Sort(0, base.Count, null);
        }

        public void Sort(IComparer<T> comparer)
        {
            this.Sort(0, base.Count, comparer);
        }

        public void Sort(int index, int count, IComparer<T> comparer)
        {
            if ((index < 0) || (count < 0))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if ((base.Count - index) < count)
            {
                throw new ArgumentOutOfRangeException("count");
            }
            this.SortItems(index, count, comparer);
        }

        protected virtual void SortItems(int index, int count, IComparer<T> comparer)
        {
            ((List<T>)base.Items).Sort(index, count, comparer);
        }

        public T[] ToArray()
        {
            return ((List<T>)base.Items).ToArray();
        }

        public T[] ToArrayThreadSafe()
        {
            lock (this)
            {
                return ToArray();
            }
        }
    }
}
