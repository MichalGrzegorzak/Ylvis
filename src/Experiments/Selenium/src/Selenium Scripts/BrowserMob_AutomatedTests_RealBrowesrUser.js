var selenium = browserMob.openBrowser();
var c = browserMob.getActiveHttpClient();

c.blacklistRequests("http(s)?://www\\.google-analytics\\.com/.*", 200);
c.blacklistRequests("http://.*\\.quantserve.com/.*", 200);
c.blacklistRequests("http://www\\.quantcast.com/.*", 200);
c.blacklistRequests("http://c\\.compete\\.com/.*", 200);
c.blacklistRequests("http(s)?://s?b\\.scorecardresearch\\.com/.*", 200);
c.blacklistRequests("http://s\\.stats\\.wordpress\\.com/.*", 200);
c.blacklistRequests("http://partner\\.googleadservices\\.com/.*", 200);
c.blacklistRequests("http://ad\\.adtegrity\\.net/.*", 200);
c.blacklistRequests("http://ad\\.doubleclick\\.net/.*", 200);
c.blacklistRequests("http(s)?://connect\\.facebook\\.net/.*", 200);
c.blacklistRequests("http://platform\\.twitter\\.com/.*", 200);
c.blacklistRequests("http://.*\\.addthis\\.com/.*", 200);
c.blacklistRequests("http://widgets\\.digg\\.com/.*", 200);
c.blacklistRequests("http://www\\.google\\.com/buzz/.*", 200);

var timeout = 30000;
selenium.setTimeout(timeout);

var tx = browserMob.beginTransaction();

var step = browserMob.beginStep("Step 1");
selenium.open("http://www.aegon.com/");
selenium.verifyTextPresent("Stock quotes");
selenium.verifyElementPresent("//table[@class='stock-quote']/tbody/tr[1]");
selenium.verifyTextPresent("AEGON 2011");
selenium.verifyElementPresent("//a[text()='Privacy statement']");
selenium.verifyElementPresent("//div[@class='grid']/div[@class='grid-items']/div[@class='span2of3']/div[@class='span1of2'][1]/div[@class='grid-item box teaser'][1]");
selenium.verifyElementPresent("//div[@class='grid']/div[@class='grid-items']/div[@class='span2of3']/div[@class='span1of2'][1]/div[@class='grid-item box teaser'][2]");
selenium.verifyElementPresent("//div[@class='grid']/div[@class='grid-items']/div[@class='span2of3']/div[@class='span1of2'][2]/div[@class='grid-item box teaser'][1]");
selenium.verifyElementPresent("//div[@class='grid']/div[@class='grid-items']/div[@class='span2of3']/div[@class='span1of2'][2]/div[@class='grid-item box teaser'][2]");
selenium.type("id=ctl00_PageHeader_GlobalNavigationControl_Search", "aegon");
browserMob.endStep();

browserMob.beginStep("Step 2");
selenium.click("id=ctl00_PageHeader_GlobalNavigationControl_SubmitSearch");
selenium.waitForPageToLoad(timeout);
selenium.verifyElementPresent("//div[@class='paging'][1]/ul/li[1]/strong/a[text()='1']");
selenium.verifyElementPresent("//div[@class='paging'][1]/ul/li[2]/a[text()='2']");
browserMob.endStep();

browserMob.beginStep("Step 3");
selenium.click("id=ctl00_MainContentPlaceHolder_TopPaging_NextLinkButton");
selenium.waitForPageToLoad(timeout);
selenium.verifyElementPresent("//div[@class='paging'][1]/a[text()='< Previous']");
selenium.type("id=ctl00_PageHeader_GlobalNavigationControl_Search", "asklahdklash");
browserMob.endStep();

browserMob.beginStep("Step 4");
selenium.click("id=ctl00_PageHeader_GlobalNavigationControl_SubmitSearch");
selenium.waitForPageToLoad(timeout);
selenium.verifyElementPresent("//div[@class='span2of3']/div[@class='grid-item']/img[@class='left attention']");
browserMob.endStep();

browserMob.beginStep("Step 5");
selenium.open("http://www.aegon.com/en/Home/About/Contact-Us/");
selenium.type("id=ctl00_MainContentPlaceHolder_email", "test@test@test");
browserMob.endStep();

browserMob.beginStep("Step 6");
selenium.click("id=ctl00_MainContentPlaceHolder_submit");
selenium.waitForPageToLoad(timeout);
selenium.verifyElementPresent("//label[@for='email' and text()='This field contains an invalid e-mailaddress']");
selenium.verifyElementPresent("//label[@for='fullname' and text()='This field is required']");
browserMob.endStep();

browserMob.beginStep("Step 7");
selenium.open("http://www.aegon.cz/cs/Domu/");
selenium.verifyElementPresent("//ul[@id='navigation-sitewide' and @class='link-list']/li[1]/a/img[@alt='secure']");
browserMob.endStep();

browserMob.beginStep("Step 8");
selenium.open("http://www.aegon.com/en/Home/Media/Press-Releases/");
selenium.verifyElementPresent("//div[@id='content-main']/div[@class='paging'][1]/a[text()='Next >']");
browserMob.endStep();

browserMob.beginStep("Step 9");
selenium.click("id=ctl00_MainContentPlaceHolder_TopPaging_NextLinkButton");
selenium.waitForPageToLoad(timeout);
selenium.verifyElementPresent("//div[@id='content-main']/div[@class='paging'][1]/a[text()='< Previous']");
browserMob.endStep();

browserMob.beginStep("Step 10");
selenium.open("http://www.aegon.com/en/Home/Sustainability/");
selenium.verifyElementPresent("//ul[@class='navigation-tree']");
selenium.verifyElementPresent("//div[@class='grid']/div[@class='span1of2'][1]/div[@class='grid-item box teaser']");
selenium.verifyElementPresent("//div[@class='grid']/div[@class='span1of2'][2]/div[@class='grid-item box teaser']");
browserMob.endStep();

browserMob.beginStep("Step 11");
selenium.open("http://www.aegon.com/en/Home/Sustainability/Sustainability-articles/2010-Reports/");
selenium.verifyElementPresent("//div[@class='title']/h1[text()='2010 Reports']");
selenium.verifyElementPresent("//div[@class='title']/em[text()='Measuring AEGON']");
selenium.verifyElementPresent("//div[@id='content-main']/div[@class='header']/span[@class='date']");
selenium.verifyElementPresent("//div[@id='content-main']/p[@class='introduction']");
selenium.verifyElementPresent("//div[@id='content-main']/div[@class='rich-text']/div[@class='rich-text']");
selenium.verifyElementPresent("//div[@id='content-related']/div[@class='box related'][1]/h3/em[text()='Related links']");
selenium.verifyElementPresent("//div[@id='content-related']/div[@class='box related'][1]/ul/li/a[1][string-length(text()) > 1]");
selenium.verifyElementPresent("//div[@id='content-related']/div[@class='box related'][2]/h3/em[text()='Related documents']");
selenium.verifyElementPresent("//div[@id='content-related']/div[@class='box related'][2]/ul/li/a[1][string-length(text()) > 1]");
browserMob.endStep();

browserMob.beginStep("Step 12");
selenium.open("http://www.aegondirect.com.hk/en/Home/AEGON-Direct-Club/Membership-Registration-Form/");
selenium.verifyElementPresent("//label[@for='chkDisclaimer']");
selenium.verifyElementPresent("//span[@class='btn btn-confirm']/input[@value='Submit']");
browserMob.endStep();

browserMob.beginStep("Step 13");
selenium.click("//input[@value='Submit']");
selenium.waitForPageToLoad(timeout);
selenium.verifyElementPresent("//label[@class='error'][1]");
browserMob.endStep();

browserMob.beginStep("Step 14");
selenium.open("http://www.aegondirect.com.hk/en/Home/QuotationEngine/Travel-Insurance/");
browserMob.endStep();

browserMob.beginStep("Step 15");
selenium.click("//a[text()='2. Our Proposal']");
selenium.waitForPageToLoad(timeout);
selenium.verifyElementPresent("//ul[@class='errors']/li/label[string-length(text()) > 0]");
browserMob.endStep();

browserMob.beginStep("Step 16");
selenium.open("http://www.aegon.com/en/Home/Investors/Quarterly-Results/2011/Q2/");
selenium.verifyElementPresent("//div[@id='content-main']/div[@class='rich-text']/table/tbody/tr[1]");
selenium.verifyElementPresent("//a[text()='html']");
selenium.verifyElementPresent("//a[text()='pdf']");
browserMob.endStep();

browserMob.endTransaction();