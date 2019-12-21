<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:output method="xml" />
  <xsl:param name="currentdate"></xsl:param>
  <xsl:template match="Transactions">

    <xsl:element name="OFX">
      <xsl:element name="SIGNONMSGSRSV1">
        <xsl:element name="SONRS">
          <xsl:element name="STATUS">
            <xsl:element name="CODE">0</xsl:element>
            <xsl:element name="SEVERITY">INFO</xsl:element>
          </xsl:element>
          <xsl:element name="DTSERVER">
            <xsl:value-of select="$currentdate" />
          </xsl:element>
          <xsl:element name="LANGUAGE">ENG</xsl:element>
        </xsl:element>
      </xsl:element>
      <xsl:element name="BANKMSGSRSV1">
        <xsl:element name="STMTTRNRS">
          <xsl:element name="TRNUID">1</xsl:element>
          <xsl:element name="STATUS">
            <xsl:element name="CODE">0</xsl:element>
            <xsl:element name="SEVERITY">INFO</xsl:element>
          </xsl:element>
          <xsl:element name="STMTRS">
            <xsl:element name="CURDEF">AUD</xsl:element>
            <xsl:element name="BANKACCTFROM">
              <xsl:element name="BANKID">RAMS</xsl:element>
              <xsl:element name="ACCTID">
                <xsl:value-of select="Account/PersonalAccount/AccountNumber" />
              </xsl:element>
              <xsl:element name="ACCTTYPE">
                <xsl:value-of select="Account/PersonalAccount/AccountType" />
              </xsl:element>
            </xsl:element>
            <xsl:element name="BANKTRANLIST">
              <xsl:element name="DTSTART">
                <xsl:value-of select="StartDate" />
              </xsl:element>
              <xsl:element name="DTEND">
                <xsl:value-of select="EndDate" />
              </xsl:element>

              <xsl:for-each select="Items/Transaction">
                <xsl:element name="STMTTRN">
                  <xsl:element name="TRNTYPE">
                    <xsl:choose>
                      <xsl:when test="IsCredit">CREDIT</xsl:when>
                      <xsl:otherwise>DEBIT</xsl:otherwise>
                    </xsl:choose>
                  </xsl:element>
                  <xsl:element name="DTPOSTED">
                    <xsl:value-of select="EffectiveDate" />
                  </xsl:element>
                  <xsl:element name="DTUSER">
                    <xsl:value-of select="CreatedDate" />
                  </xsl:element>
                  <xsl:element name="TRNAMT">
                    <xsl:value-of select="Amount" />
                  </xsl:element>
                  <xsl:element name="FITID" />
                  <xsl:element name="NAME">
                    <xsl:value-of select="Reference" />
                  </xsl:element>
                  <xsl:element name="MEMO">
                    <xsl:value-of select="Reference" />
                  </xsl:element>
                </xsl:element>
              </xsl:for-each>

            </xsl:element>
            <xsl:element name="LEDGERBAL">
              <xsl:element name="BALAMT">
                <xsl:value-of select="Account/PersonalAccount/CurrentBalance" />
              </xsl:element>
              <xsl:element name="DTASOF">
                <xsl:value-of select="EndDate" />
              </xsl:element>
            </xsl:element>
          </xsl:element>
        </xsl:element>
      </xsl:element>
    </xsl:element>
  </xsl:template>
</xsl:stylesheet>