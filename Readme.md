MVC Core Features

MVC Architecture – Clear separation of concerns between Models, Views, and Controllers.

Request Pipeline Basics – Request flow: Routing → Controller → Action → View.

Controllers & Action Methods – Standard controller actions returning different results.

ActionResult Types – Implemented ViewResult and JsonResult.

Parameter Binding – Action parameters bound automatically from query string, form data, or route values.

🔹 Data Passing & State Management

TempData, ViewBag, ViewData – Used for sharing data between controllers and views.

Session State – Maintains user-specific data across requests.

Cookies – Stores small amounts of client-side data.

Query Strings & Hidden Fields – Lightweight techniques for passing data between requests.

🔹 Dependency Injection & Attributes

Dependency Injection – Controller constructor injection for service/repository access.

Controller Attributes – Implemented [Route] and [HttpGet] for better routing control.

🔹 Views & Razor

Razor Syntax – Dynamic HTML rendering using @model, @Html.*, and C# inline code.

Layouts – Centralized layout file (_Layout.cshtml) for consistent UI.

Strongly Typed Views – Views bound to specific models.

🔹 Forms & Validation

Forms – Implemented using Html.BeginForm, TextBoxFor, and other Razor helpers.

Data Annotations – Validation attributes like [Required], [Range].

Server-side Validation – Validation with ModelState.IsValid.

Client-side Validation – jQuery unobtrusive validation.

Anti-Forgery Tokens – CSRF protection in forms.

🔹 Routing & Areas

Conventional Routing – Default {controller}/{action}/{id} route.

Attribute Routing – [Route].

Areas – Modular project structure for separation of features.

🔹 AJAX & JSON

jQuery + AJAX – Asynchronous data loading without full page refresh.

JSON Responses – Using JsonResult for AJAX API responses.

🔹 Security & Configuration

User Secrets – Secure storage of sensitive data 