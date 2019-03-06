# Collections
Task #1 Search in Array
  1) Implement code that searches in an array for an item with specified PartNumber.

Task #2 Replace T[] with List<T>
  1) Replace Orderlteml] array with List<Orderltem> in Order class. 
  2) Order class should have full ownership of list of orders make_orderltems field readonly. 
  3) Implement search for a list item.
  
Task #3 - Replace List<T> with KeyedCollection<TKey,TItem>
  1) Replace List<T> array with KeyedCollection<TKey, TItem> in Order class.
  
Task #4 Use ReadOnlyCollection<T> 
  1) Change _orderltems field's type to List<T>.
  2) Change OrderItems property to IReadOnlyList<T> and return ReadOnlyCollection<T>.
  3) Add AddRange method that receives IEnumerable<T> and adds all sequence elements to the_orderltems collection.
  
Task #5 Use Dictionary<TKey, TValue>
  1) Add Dictionary<,> field for fast searching.
  2) Implement FindByPartNumber.
  3) Implement FindByDescription.
  
Task #6 yield
  1) Implement GetSequence(int count).
  2) Implement GetSequence().
  
Task #7 Struct Dictionary Key
  1) Copy DbGenerator from previous task.
  2) Implement Equals & GetHashCode.
  3) Implement FindBy.
