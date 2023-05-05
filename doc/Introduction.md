# Introduction
**EasyScript** - это простой язык програмирования. Предназначиный как дополнение к проэктам.
Является динамически типизрованым языком програмирования.

**Пока в ранней разработке**

## Syntaxis
> Сomments

`// Simple Comment`

`/* Multiline Comment */`

> Create a mutable variable

`var name = 10`

> Creating an immutable variable, **constant**

`const a = 10`

> Changing a variable

`a = 10`

> Calling Functions

`name(arguments)`

> Standard Functions

* See [Libraries](##Libraries)

> Cycles
>> `while (condition) {}`

>> `do {} while (condition)`

>> `for (var i = 0, i < 10, i = i + 1) {}`

> Создание функцый

```es
func test(key1, key2) {
    print(key1, key2)
}
```

## Libraries
* [Math](https://github.com/EtherCD/EasyScript/blob/master/doc/libs/Math.md)
* [Sys](https://github.com/EtherCD/EasyScript/blob/master/doc/libs/Sys.md)