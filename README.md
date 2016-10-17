# GoGreen
Our project for our Software Engineering class at University of Baguio.

<br /><br />

<h3>First time use</h3>
PRESS Control + Shift + B<br /><br />



<strong>To create a default account (Do this once):</strong><br />
1. OPEN 'Package Manager Console' (Tools > NuGet Package Manager > Package Manager Console)<br />
2. TYPE 'Update-Database' without quotation marks<br />
3. FINISH<br />
<strong>NOTE:</strong> The default account's email is 'admin@gogreen.com' and password is 'Admin-0' without quotation mark<br /><br />



<strong>To register a new account, do the following first (Do it only once):</strong><br />
1. LOGIN using the default account<br />
2. CLICK 'Agency' on navigation bar then click 'Add Agency'<br />
3. FILL all necessary details<br />
4. REGISTER<br /><br />



<strong>To test email confirmation:</strong><br />
1. CHANGE the following code in 'App_Start > IdentityConfig.cs' line 77<br />
var mail = new System.Net.Mail.MailMessage(sentFrom, "jessisibayan@gmail.com"); to<br />
var mail = new System.Net.Mail.MailMessage(sentFrom, YOUR_EMAIL_HERE); // change YOUR_EMAIL_HERE to your own email (Gmail only)<br />
2. PRESS Control + Shift + B<br />
3. REGISTER
