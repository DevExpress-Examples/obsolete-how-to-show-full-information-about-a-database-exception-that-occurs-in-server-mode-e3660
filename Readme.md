<!-- default file list -->
*Files to look at*:

* [Main.cs](./CS/LinqServerMode/Main.cs) (VB: [Main.vb](./VB/LinqServerMode/Main.vb))
* [MyGridControl.cs](./CS/LinqServerMode/MyGridControl.cs) (VB: [MyGridControl.vb](./VB/LinqServerMode/MyGridControl.vb))
* [MyGridView.cs](./CS/LinqServerMode/MyGridView.cs) (VB: [MyGridView.vb](./VB/LinqServerMode/MyGridView.vb))
* [MyGridViewInfoRegistrator .cs](./CS/LinqServerMode/MyGridViewInfoRegistrator .cs) (VB: [MyGridViewInfoRegistrator .vb](./VB/LinqServerMode/MyGridViewInfoRegistrator .vb))
* [Program.cs](./CS/LinqServerMode/Program.cs) (VB: [Program.vb](./VB/LinqServerMode/Program.vb))
<!-- default file list end -->
# How to show full information about a database exception that occurs in Server Mode


<p>By default, if any database exception occurs in Server Mode, a tooltip is shown at the bottom left corner of a grid. This tooltip shows the first 50 characters of this exception. </p><p>You can show a full exception text in a tooltip. For this, it is necessary to create a custom grid and override the <strong>GridView.CheckDataControllerError method</strong>. </p><p>In addition, you can override the<strong> </strong><strong>GridView.OnDataControllerError method</strong> to catch the moment when a database exception occurs. In this method, you can implement visual feedback corresponding to this exception. </p><p>This example illustrates how to accomplish this task. To see an exception, group data against the Home Page column. </p>

<br/>


