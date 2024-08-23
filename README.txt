Reproduction steps.

Place breakpoint on line 20 of MyDelegatingHandler.cs.

Open app from the root path /.
Navigate to counter page from the menu.
In this case circuit accessor was set before oninitialized call and we have scoped service with correct value.

Now navigate your browser from address bar directly to the /counter page.
In this case oninitilaized is processed before circuit accessor sets context resulting in null value in Context object.
That value is set on MainLayout OnInitialized.