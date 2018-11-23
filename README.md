# Value objects

> A small simple object, like money or a date range, whose equality isn't based on identity. - [Martin Fowler](https://martinfowler.com/eaaCatalog/valueObject.html)

I like to think of this as a way to build our own primitive types. 

## Problem

Primitive types can be too generic and can hold any value of that type but the specifics of our code might not allow for ALL values of that type.

## Example 

First, lets talk about books and some of the properties of a book. A book can have a title, an author, publish year, publisher, chapters, a page count, and probably many other things. A simple class definition for a book might look something like this: 

```csharp
public class Book
{
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }
        public int PageCount { get; set; }
}
```

This looks useful for defining our book but we immediately start running into issues when we start trying to use it for anything, like add/update:

```csharp
public static List<Book> _bookCollection = new List<Book>();

static void Main(string[] args)
{
    _bookCollection.Add(new Book { Title = "IT", Author = "Stephen King", PublishYear = -3, PageCount = -5000 });
    _bookCollection.Add(new Book { Title = "The Winds of Winter", Author = "George R. R. Martin", PublishYear = 9999, PageCount = 1200085410 });

    _bookCollection.ForEach(b => Console.WriteLine($"{b.Title} ({b.PublishYear})...{b.PageCount}"));
    Console.ReadKey();
}
```

**WTF?!?!?!** How can a book have negative pages or be published in the future, also -3 _WHAT_, (C.E., B.C.E., something else). We could go into all of the function that have anything to do with the business logic involved with adding/updating the database and write our logic but then we would have to duplicate everything whereever we are using it, and when we go into update it sometime down the road we are going to forget all the places we have that logic to update (HERE COME THE BUGS). Instead we could use a `ValueObject` to isolate all of that logic to one place and always ensure that it is run correctly.

## Solution 

A `ValueObject` is just a small class that allows us to define our own primitive types in code, like making smart ints.

Let's start with PageCount and what makes an integer not a good choice.

- Page counts cannot be negative, or zero.
- Math on page count isn't useful. _I can't add PageCounts together to get a longer book, well maybe that's crazy._
- The longest book ever written is not anywhere close to `int.MaxValue` so we can put some meaningful max on this as well.

### Our new value object

```csharp
public class PageCount
{
    public PageCount(int value)
    {
        if (value <= 0 || value > 50000) throw new InvalidPageCountException();

        Value = value;
    }

    public int Value { get; }

    public override string ToString() => return $"{Value} pages";

    public static implicit operator PageCount(int value)
    {
        return new PageCount(value);
    }
}
```

Now, we can go into our book object and update the `PageCount` property to be of type `PageCount` and KA-BLAMO everywhere that was updating PageCount has logic on the value.

**NOTE** because of the way this is implemented we will begin throwing exceptions when we have an invalid page count, if the system doesn't handle errors well in all situations you may be causing unknown side effects. If this is the case you should still use value objects but probably not implicitly convert to them, making it easier to find all the use cases for refactoring.

### Closing

Tired of reading me butcher what a value object is and how to use it? Check out these awesome references:

- [Weekly Dev Tips - Primitive Obsession](http://www.weeklydevtips.com/012)
- [Value Objects Like a Pro](https://hackernoon.com/value-objects-like-a-pro-f1bfc1548c72)
- [Implement value objects](https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/implement-value-objects)
- [Dealing with primitive obsession](https://lostechies.com/jimmybogard/2007/12/03/dealing-with-primitive-obsession/)
- [From Primitive Obsession to Domain Modelling](http://blog.ploeh.dk/2015/01/19/from-primitive-obsession-to-domain-modelling/)

Check out the [GitHub Repo](https://github.com/timscriv/value-objects) that accompanies this post for more examples and work. 

I hope you found this useful and will help you solve more problems!
