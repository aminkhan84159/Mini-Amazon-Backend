namespace Amazon.Api.Entities.Communication
{
    public class WelcomeEmailDto
    {
        public string RecipientEmail { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Body { get; set; } = null!;

        public static WelcomeEmailDto MapToEmail(string firstName, string lastName, string email, string role) {
            WelcomeEmailDto data = new WelcomeEmailDto()
            {
                RecipientEmail = email,
                Subject = "Welcome to Amazon!"
            };
            if (role == "Customer")
            {
                data.Body = $@"
                    <!DOCTYPE html>
                    <html lang=""en"">
                    <head>
                        <meta charset=""UTF-8"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <title>Welcome to Amazon</title>
                    </head>
                    <body style=""margin: 0; padding: 0; font-family: Arial, Helvetica, sans-serif; background-color: #f4f4f4;"">
                        <table width=""100%"" cellpadding=""0"" cellspacing=""0"" style=""background-color: #f4f4f4; padding: 20px;"">
                            <tr>
                                <td align=""center"">
                                    <table width=""600"" cellpadding=""0"" cellspacing=""0"" style=""background-color: #ffffff; border-radius: 8px; overflow: hidden;"">
                                        <tr>
                                            <td style=""padding: 20px; text-align: center; background-color: #ff9900; color: #ffffff;"">
                                                <h1 style=""margin: 0; font-size: 28px;"">Welcome to Amazon, {firstName} {lastName}!</h1>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style=""padding: 30px; color: #333333; font-size: 16px; line-height: 1.5;"">
                                                <p style=""margin: 0 0 20px;"">Dear {firstName} {lastName},</p>
                                                <p style=""margin: 0 0 20px;"">We’re thrilled to have you join the Amazon family! Get ready to explore a world of endless shopping possibilities, from exclusive deals to lightning-fast delivery. Your journey with us starts now, and we can’t wait to make it an amazing experience.</p>
                                                <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                                    <tr>
                                                        <td style=""text-align: center; padding: 20px 0;"">
                         <!-- Postimages-->               <img src=""https://i.postimg.cc/3JbyhnKF/Welcome-Banner.png"" alt=""Welcome Banner"" style=""max-width: 100%; height: auto; border-radius: 8px;"">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <p style=""margin: 20px 0;"">Here’s what you can do next:</p>
                                                <ul style=""margin: 0 0 20px; padding-left: 20px;"">
                                                    <li><strong>Shop Now</strong>: Discover millions of products at unbeatable prices. <a href=""https://www.amazon.com"" style=""color: #0073bb; text-decoration: none;"">Click here to start shopping!</a></li>
                                                    <li><strong>Personalize Your Experience</strong>: Update your preferences to get tailored recommendations.</li>
                                                    <li><strong>Join Amazon Prime</strong>: Unlock free shipping, exclusive deals, and more with a Prime membership.</li>
                                                </ul>
                                                <p style=""margin: 0 0 20px;"">If you have any questions, our support team is here 24/7. Just reach out at <a href=""mailto:support@amazon.com"" style=""color: #0073bb; text-decoration: none;"">support@amazon.com</a>.</p>
                                                <p style=""margin: 0;"">Thank you for choosing Amazon. Let’s make shopping fun, fast, and fabulous!</p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style=""padding: 20px; text-align: center; background-color: #f4f4f4; color: #333333; font-size: 14px;"">
                                                <p style=""margin: 0;"">Best regards,<br>The Amazon Team</p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </body>
                    </html>";
            }
            else if(role == "Vendor")
            {
                data.Body = $@"
                        <!DOCTYPE html>
                        <html lang=""en"">
                        <head>
                            <meta charset=""UTF-8"">
                            <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                            <title>Welcome to Amazon Vendor Program</title>
                        </head>
                        <body style=""margin: 0; padding: 0; font-family: Arial, Helvetica, sans-serif; background-color: #f4f4f4;"">
                            <table width=""100%"" cellpadding=""0"" cellspacing=""0"" style=""background-color: #f4f4f4; padding: 20px;"">
                                <tr>
                                    <td align=""center"">
                                        <table width=""600"" cellpadding=""0"" cellspacing=""0"" style=""background-color: #ffffff; border-radius: 8px; overflow: hidden;"">
                                            <tr>
                                                <td style=""padding: 20px; text-align: center; background-color: #232f3e; color: #ffffff;"">
                                                    <h1 style=""margin: 0; font-size: 26px;"">Welcome to Amazon Vendor Program, {firstName} {lastName}!</h1>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style=""padding: 30px; color: #333333; font-size: 16px; line-height: 1.5;"">
                                                    <p style=""margin: 0 0 20px;"">Dear {firstName} {lastName},</p>
                                                    <p style=""margin: 0 0 20px;"">We’re excited to have you onboard as a vendor partner with Amazon. Together, we’ll deliver millions of products to customers worldwide and grow your business faster with Amazon’s trusted platform.</p>
                                                    <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                                        <tr>
                                                            <td style=""text-align: center; padding: 20px 0;"">
                                                                <img src=""https://i.postimg.cc/3JbyhnKF/Welcome-Banner.png"" alt=""Welcome Banner"" style=""max-width: 100%; height: auto; border-radius: 8px;"">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <p style=""margin: 20px 0;"">Here’s what you can do next:</p>
                                                    <ul style=""margin: 0 0 20px; padding-left: 20px;"">
                                                        <li><strong>List Your Products</strong>: Add your products to reach millions of Amazon shoppers.</li>
                                                        <li><strong>Manage Your Store</strong>: Use the Vendor Dashboard to track sales, inventory, and performance.</li>
                                                        <li><strong>Promote Your Brand</strong>: Run ads and promotions to boost visibility.</li>
                                                    </ul>
                                                    <p style=""margin: 0 0 20px;"">If you need any help, our vendor support team is here 24/7. Contact us at <a href=""mailto:vendorsupport@amazon.com"" style=""color: #0073bb; text-decoration: none;"">vendorsupport@amazon.com</a>.</p>
                                                    <p style=""margin: 0;"">Thank you for partnering with Amazon. Let’s grow together!</p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style=""padding: 20px; text-align: center; background-color: #f4f4f4; color: #333333; font-size: 14px;"">
                                                    <p style=""margin: 0;"">Best regards,<br>The Amazon Vendor Team</p>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </body>
                        </html>";
            }
            return data;
        }
    }
}
