using System;
using System.Collections;
using System.Collections.Generic;

namespace ListUtil;
/// <summary>
/// Represents a sorted list that is updated lazily.
/// </summary>
/// <typeparam name="T">The type of elements in the list.</typeparam>
public class LazySortList<T> : IList<T> where T : IComparable<T>
{
    private List<T> list = new List<T>();
    private List<T> added = new List<T>();
    private List<T> removed = new List<T>();
    private bool isModified = false;

    /// <summary>
    /// Gets or sets the element at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the element to get or set.</param>
    /// <returns>The element at the specified index.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if the index is less than 0 or greater than or equal to the number of elements in the list.
    /// </exception>
    public T this[int index]
    {
        get
        {
            Update();
            return list[index];
        }
        set
        {
            Update();
            list[index] = value;
        }
    }

    /// <summary>
    /// Gets the number of elements in the list.
    /// </summary>
    public int Count
    {
        get
        {
            Update();
            return list.Count;
        }
    }

    public bool IsReadOnly
    {
        get
        {
            return false;
        }
    }

    public void Add(T item)
    {
        added.Add(item);
        isModified = true;
    }

    public void Clear()
    {
        list.Clear();
        added.Clear();
        removed.Clear();
    }

    public bool Contains(T item)
    {
        Update();
        return list.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        Update();
        list.CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        Update();
        return list.GetEnumerator();
    }

    public int IndexOf(T item)
    {
        Update();
        return list.IndexOf(item);
    }

    public void Insert(int index, T item)
    {
        added.Add(item);
        isModified = true;
    }

    public bool Remove(T item)
    {
        removed.Add(item);
        isModified = true;
        return true;
    }

    public void RemoveAt(int index)
    {
        Update();
        removed.Add(list[index]);
        isModified = true;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        Update();
        return ((IEnumerable)list).GetEnumerator();
    }

    private void Update()
    {
        if (!isModified)
        {
            return;
        }

        added.Sort();
        removed.Sort();

        MergeLists(list, added, removed);
        added.Clear();
        removed.Clear();
        isModified = false;
    }

    private void MergeLists(List<T> list, List<T> added, List<T> removed)
    {
        var result = new List<T>();

        int i = 0;
        int j = 0;
        int k = 0;

        while (i < list.Count || j < added.Count)
        {
            if (k < removed.Count)
            {
                if (i < list.Count && removed[k].CompareTo(list[i]) == 0)
                {
                    k++;
                    i++;
                    continue;
                }
                if (j < added.Count && removed[k].CompareTo(added[j]) == 0)
                {
                    k++;
                    j++;
                    continue;
                }
            }
            if (j < added.Count && (i >= list.Count || added[j].CompareTo(list[i]) < 0))
            {
                result.Add(added[j]);
                j++;
            }
            else
            {
                result.Add(list[i]);
                i++;
            }
        }

        this.list = result;
    }

}
