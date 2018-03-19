var c = browserMob.openHttpClient()

// Converted scripts shouldn't follow redirects by default
// If you change this, make sure you aren't issuing multiple requests below
c.setFollowRedirects(false);

browserMob.beginTransaction();

// AEGON.COM
browserMob.beginStep('Step 1');
c.get('http://www.aegon.com', 200);
browserMob.endStep();

browserMob.beginStep('Step 2');
c.get('http://www.aegon.com/en/Home/Media/Press-Releases/', 200);
browserMob.endStep();

browserMob.beginStep('Step 3');
c.get('http://www.aegon.com/en/Home/Sustainability/', 200);
browserMob.endStep();

browserMob.beginStep('Step 4');
c.get('http://www.aegon.com/en/Home/Sustainability/Sustainability-articles/2010-Reports/', 200);
browserMob.endStep();

browserMob.beginStep('Step 5');
c.get('http://www.aegon.com/en/Home/Investors/Quarterly-Results/2011/Q2/', 200);
browserMob.endStep();

browserMob.beginStep('Step 6');
c.get('http://www.aegon.com/en/Home/About/Contact-Us/', 200);
browserMob.endStep();

// AEGON.CZ
browserMob.beginStep('Step 7');
c.get('http://www.aegon.cz', 302);
browserMob.endStep();

browserMob.beginStep('Step 8');
c.get('http://www.aegon.cz/cs/Domu/', 200);
browserMob.endStep();

// AEGONDIRECT.COM.HK
browserMob.beginStep('Step 9');
c.get('http://www.aegondirect.com.hk/en/Home/AEGON-Direct-Club/Membership-Registration-Form/', 200);
browserMob.endStep();

browserMob.beginStep('Step 10');
c.get('http://www.aegondirect.com.hk/en/Home/QuotationEngine/Travel-Insurance/', 200);
browserMob.endStep();

// Other site home pages
browserMob.beginStep('Step 11');
c.get('http://www.adms-asia.com', 200);
browserMob.endStep();

browserMob.beginStep('Step 12');
c.get('http://www.adms-asia.com.au', 200);
browserMob.endStep();

browserMob.beginStep('Step 13');
c.get('http://www.adms-asia.com.hk', 200);
browserMob.endStep();

browserMob.beginStep('Step 14');
c.get('http://www.transamerica.co.in', 302);
browserMob.endStep();

browserMob.beginStep('Step 15');
c.get('http://www.transamerica.in', 302);
browserMob.endStep();

browserMob.beginStep('Step 16');
c.get('http://www.aegonassetmanagement.com', 200);
browserMob.endStep();

browserMob.beginStep('Step 17');
c.get('http://www.aegoncan.com', 302);
browserMob.endStep();

browserMob.beginStep('Step 18');
c.get('http://www.aegondirect.com.hk', 302);
browserMob.endStep();

browserMob.beginStep('Step 19');
c.get('http://www.aegon.de', 302);
browserMob.endStep();

browserMob.beginStep('Step 20');
c.get('http://www.aegonglobalpensions.com', 200);
browserMob.endStep();

browserMob.beginStep('Step 21');
c.get('http://www.aegoninvestments.com', 302);
browserMob.endStep();

browserMob.beginStep('Step 22');
c.get('http://www.aegon.jp', 302);
browserMob.endStep();

browserMob.beginStep('Step 23');
c.get('http://www.aegonrealty.com', 200);
browserMob.endStep();

browserMob.beginStep('Step 24');
c.get('http://www.aegon.com.tr', 302);
browserMob.endStep();

browserMob.beginStep('Step 24');
c.get('http://www.verenigingaegon.nl', 200);
browserMob.endStep();

browserMob.endTransaction();