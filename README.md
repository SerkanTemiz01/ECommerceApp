# ECommerceApp


## Login page

![image](https://user-images.githubusercontent.com/115589345/213008703-7c8b6b3e-c7a7-4569-8b48-5a2022b19e78.png)


## If you have admin email and password, you can access admin controller.

### This page show List of Managers. Admin add,delete and update managers and manager's info. I use session and Authorazation in this poject.

![image](https://user-images.githubusercontent.com/115589345/213009221-6104a6c1-25d6-4bb6-9c4b-94d9dac56d46.png)


![image](https://user-images.githubusercontent.com/115589345/213009487-07e7acbd-d991-4265-bee4-64cc7cc4c736.png)


### There are API and MVC in this project.I've used Onion Architecture. I take data from View in MVC and make a request to API to post this data and add database. System works like that. 

![image](https://user-images.githubusercontent.com/115589345/213010274-ee47a213-ea27-4961-87e1-f03585f128b2.png)


### In the context of C#, a dependency resolver is a component or library that is used to manage the dependencies of a .NET application. It is responsible for resolving and instantiating objects that are required by other objects in the application.

There are several dependency resolver libraries available for C#, such as Microsoft's built-in dependency injection (DI) framework, which is part of the ASP.NET Core framework. The most popular dependency injection libraries for C# are Autofac, Ninject, and Simple Injector. These libraries provide a consistent way to configure and manage dependencies, making it easier to write testable, maintainable and extensible code.

Dependency injection is a design pattern and a technique that allows to remove hard-coded dependencies between objects, providing instead the required dependencies through a constructor, a property or a method parameter. With dependency injection, the responsibility of creating and managing object dependencies is delegated to a dedicated component, the dependency resolver.

![image](https://user-images.githubusercontent.com/115589345/213014435-330d1d1d-24f7-4864-83f0-4bd595f20579.png)
![image](https://user-images.githubusercontent.com/115589345/213014634-a5395f4e-11b7-4de9-a31d-73f84c431a0d.png)



### I used this project for verifying the identity of a user or client in a computer system. In the context of C#, there are several ways to implement authentication, depending on the specific requirements of the application. And I also add filter method to route and direct all pages to login page.

### Cookies-based session: This stores the session data in a cookie on the user's browser. This is a popular option, but can be less secure if sensitive information is stored in the cookie.

![image](https://user-images.githubusercontent.com/115589345/213014831-309d7ad7-de70-48f0-a52d-0438efc0db36.png)


