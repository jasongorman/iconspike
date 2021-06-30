<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
 xmlns:msxsl="urn:schemas-microsoft-com:xslt">	
	<xsl:template match="/">		
		<xsl:apply-templates select="root/view"/>	
	</xsl:template>	
	<xsl:template match="view[@type='LoginView']">		
		<html>			
			<head>				
				<title>Log in</title>			
			</head>			
			<body>				
				<p></p>				
				<p align="center">					
					<font color="red">						
						<xsl:value-of select="./@Message"/>					
					</font>				
				</p>				
				<form id="frmLogin" name="frmLogin" method="post" action="default.aspx?event=login&amp;sender={./@Name}">					
					<table align="center" width="50%">						
						<tr>							
							<td>User ID</td>							
							<td>								
								<input type="text" id="{./@Name}.UserId" name="{./@Name}.UserId" value="{./@UserId}"/>							
							</td>						
						</tr>						
						<tr>							
							<td>Password</td>							
							<td>								
								<input type="password" id="{./@Name}.Password" name="{./@Name}.Password" value="{./@Password}"/>							
							</td>						
						</tr>					
					</table>					
					<p align="center">						
						<input type="submit" name="login" id="login" value="Log in"/>					
					</p>				
				</form>			
			</body>		
		</html>	
	</xsl:template>
</xsl:stylesheet>