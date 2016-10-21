# GoGreen
Our project for our Software Engineering class at University of Baguio.

<br /><br />

<h3>BUILD:</h3>
Press Control + Shift + B<br /><br />

<strong>To test email confirmation:</strong><br />
1. CHANGE the following code in 'App_Start > IdentityConfig.cs' line 77<br />
var mail = new System.Net.Mail.MailMessage(sentFrom, "jessisibayan@gmail.com");<br />
var mail = new System.Net.Mail.MailMessage(sentFrom, message.Destination);<br />
2. BUILD<br />
3. REGISTER<br /><br />

<strong>To update project:</strong><br />
1. DOWNLOAD https://github.com/Jessi810/GoGreen/archive/master.zip<br />
2. EXTRACT to previous project location (Copy and Replace)<br />
3. BUILD<br />

## License

See the [LICENSE](LICENSE.md) file for license rights and limitations (MIT).
