# LazySortList

The `LazySortList` class represents a sorted list that is updated lazily. It is a generic class that implements the `IList` interface, and it can be used to store a collection of elements that are sorted according to their natural ordering.

## Usage

To use the `LazySortList` class, you need to specify the type of elements that the list will contain as a type parameter. For example:

  LazySortList<int> intList = new LazySortList<int>();
  LazySortList<string> stringList = new LazySortList<string>();
  
You can then use the `Add` method to add elements to the list, and the `Remove` method to remove elements from the list. The `Contains` method can be used to check if the list contains a specific element, and the `Clear` method can be used to remove all elements from the list.

## Features

- The `LazySortList` class is designed to be updated lazily, which means that the list is only sorted when it is modified or when an operation that requires the list to be sorted is performed. This can help improve the performance of the `LazySortList` class in cases where the list is modified frequently but the sorted order is not needed immediately.
- The `LazySortList` class implements the `IList` interface, which means that it provides a set of methods and properties for manipulating a collection of elements. This includes methods for adding, removing, and searching for elements, as well
