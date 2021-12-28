namespace DelegatesAndEvents
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <inheritdoc cref="IObservableList{T}" />
    public class ObservableList<TItem> : IObservableList<TItem>
    {
        private readonly IList<TItem> _list = new List<TItem>();

        /// <inheritdoc cref="IObservableList{T}.ElementInserted" />
        public event ListChangeCallback<TItem> ElementInserted;

        /// <inheritdoc cref="IObservableList{T}.ElementRemoved" />
        public event ListChangeCallback<TItem> ElementRemoved;

        /// <inheritdoc cref="IObservableList{T}.ElementChanged" />
        public event ListElementChangeCallback<TItem> ElementChanged;

        /// <inheritdoc cref="ICollection{T}.Count" />
        public int Count => this._list.Count;

        /// <inheritdoc cref="ICollection{T}.IsReadOnly" />
        public bool IsReadOnly => this._list.IsReadOnly;

        /// <inheritdoc cref="IList{T}.this" />
        public TItem this[int index]
        {
            get => this._list[index];
            set
            {
                var oldElem = this._list[index];
                this._list[index] = value;
                ElementChanged(this, value, oldElem, index);
            }
        }

        /// <inheritdoc cref="IEnumerable{T}.GetEnumerator" />
        public IEnumerator<TItem> GetEnumerator() => this._list.GetEnumerator();

        /// <inheritdoc cref="IEnumerable.GetEnumerator" />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <inheritdoc cref="ICollection{T}.Add" />
        public void Add(TItem item)
        {
            this._list.Add(item);
            ElementInserted(this, item, this.Count - 1);
        }

        /// <inheritdoc cref="ICollection{T}.Clear" />
        public void Clear()
        {
            var tempList = new List<TItem>(this._list);
            this._list.Clear();
            for (int i = 0; i < tempList.Count; i++)
                ElementRemoved(this, tempList[i], i);
        }

        /// <inheritdoc cref="ICollection{T}.Contains" />
        public bool Contains(TItem item) => this._list.Contains(item);

        /// <inheritdoc cref="ICollection{T}.CopyTo" />
        public void CopyTo(TItem[] array, int arrayIndex) => this._list.CopyTo(array, arrayIndex);

        /// <inheritdoc cref="ICollection{T}.Remove" />
        public bool Remove(TItem item)
        {
            var index = this._list.IndexOf(item);
            if (index != -1)
            {
                this._list.RemoveAt(index);
                ElementRemoved(this, item, index);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc cref="IList{T}.IndexOf" />
        public int IndexOf(TItem item) => this._list.IndexOf(item);

        /// <inheritdoc cref="IList{T}.Insert" />
        public void Insert(int index, TItem item)
        {
            this._list.Insert(index, item);
            ElementInserted(this, item, index);
        }

        /// <inheritdoc cref="IList{T}.RemoveAt" />
        public void RemoveAt(int index)
        {
            var item = this._list[index];
            this._list.RemoveAt(index);
            ElementRemoved(this, item, index);
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals(obj as ObservableList<TItem>);
        }

        /// <summary>
        /// Compare two istance of <see cref="ObservableList{TItem}"/> class.
        /// </summary>
        /// <returns>true if the two instaces are equal, false otherwise</returns>
        public bool Equals(ObservableList<TItem> other)
        {
            return this._list.Equals(other._list);
        }

        /// <inheritdoc cref="object.GetHashCode" />
        public override int GetHashCode() => this._list.GetHashCode();

        /// <inheritdoc cref="object.ToString" />
        public override string ToString()
        {
            return $"{nameof(ObservableList<TItem>)}["
                   + string.Join(", ", this._list)
                   + "]";
        }
    }
}
