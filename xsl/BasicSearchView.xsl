<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:include href="FieldCriteriaView.xsl"/>
	<xsl:include href="DateCriteriaView.xsl"/>
	<xsl:include href="DocumentTypesView.xsl"/>
	<xsl:template match="/">
		<html>
			<head>						
				<title>Basic Search</title>
			</head>
			<body>
				<xsl:apply-templates select="root/view"/>
			</body>
		</html>
	</xsl:template>
	<!-- BasicSearchView template -->
	<xsl:template match="view[@type='BasicSearchView']">
		<form method="POST" action="default.aspx?event=update&amp;sender={@Name}">
			<table border="0" bgcolor="blue" align="center" width="90%">
				<tr>
					<td bgcolor="paleturquoise">
						<xsl:apply-templates select="view[@type='FieldCriteriaView']"/>
						<P>
							<FONT face="MS Sans Serif" size="1"></FONT>
						</P>
						<P>
							<xsl:apply-templates select="view[@type='DateCriteriaView']"/>
						</P>
						<P>
							<FONT face="MS Sans Serif" size="1"></FONT>
						</P>
						<P>
							<TABLE id="Table3" height="51" cellSpacing="1" cellPadding="1" width="479" border="0">
								<TR>
									<TD>
										<FONT face="MS Sans Serif" size="1">That contains these words or phrases:</FONT>
									</TD>
								</TR>
								<TR>
									<TD>
										<INPUT id="{@Name}.Contains" type="text" size="69" name="{@Name}.Contains" value="{@Contains}"/>
										<FONT face="MS Sans Serif" size="1"></FONT>
									</TD>
								</TR>
							</TABLE>
							<TABLE id="Table4" height="51" cellSpacing="1" cellPadding="1" width="479" border="0">
								<TR>
									<TD>
										<EM>
											<FONT color="#ff0000" face="MS Sans Serif" size="1">...but not these words or
											phrases:</FONT>
										</EM>
									</TD>
								</TR>
								<TR>
									<TD>
										<INPUT id="{@Name}.NotContains" type="text" size="69" name="{@Name}.NotContains" value="{@NotContains}"/>
									</TD>
								</TR>
							</TABLE>
						</P>
						<P>
							<FONT face="MS Sans Serif" size="1"></FONT>
						</P>
						<P>
							<xsl:apply-templates select="view[@type='DocumentTypesView']"/>
						</P>
					</td>
				</tr>
			</table>
			<P></P>
		</form>
	</xsl:template>
</xsl:stylesheet>