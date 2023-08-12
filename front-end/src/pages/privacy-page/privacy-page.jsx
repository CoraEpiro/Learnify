import { motion } from "framer-motion";
import "./privacy-page.css";

const PrivacyPage = () => {
  document.title = "Privacy and Policy for Learnify";

  return (
    <motion.div
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      className={
        "mt-3 px-16 py-8 mx-28 bg-white rounded-lg flex flex-col gap-4"
      }
    >
      <h1 className="primary-header">Privacy Policy</h1>
      <p className="text">Effective Dec 20, 2018</p>
      <p className="text">This policy covers Learnify.</p>

      <h3 className="header">What information Learnify collects and Why</h3>
      <p className="text">
        In order to give you the best possible experience using Learnify, we
        collect information from your interactions with our network. We use
        common internet technologies, such as cookies and web server logs. We
        collect this basic information from everybody, whether they have an
        account or not.
      </p>
      <p className="text">
        The information we collect about all visitors to our website includes:
      </p>
      <ul className="ul">
        <li className="li">The visitor’s browser type</li>
        <li className="li">Referring site</li>
        <li className="li">The date and time of each visitor request</li>
        <li className="li">
          We also collect potentially personally-identifying information like
          Internet Protocol (IP) addresses.
        </li>
      </ul>
      <p className="text">We use this information to:</p>
      <ul className="ul">
        <li className="li">
          Provide, test, improve, promote and personalize Learnify Services
        </li>
        <li className="li">Fight spam and other forms of abuse</li>
        <li className="li">
          Generate aggregate, non-identifying information about how people use
          Learnify Services
        </li>
      </ul>
      <p className="text">
        In order for you to create an account on Learnify and use our Services,
        we need to collect and process certain information. Depending on your
        use of the Services, that may include:
      </p>
      <ul className="ul">
        <li className="li">
          Communications you send to us (for example, when you ask for support,
          send us questions or comments, or report a problem);
        </li>
        <li className="li">
          Information that you submit on or to Learnify in the form of
          reactions, comments, or messages to other users;
        </li>
        <li className="li">
          The email address associated with your Twitter account, if you choose
          to sign up using your Twitter credentials. Learnify will also request
          permission to access additional information (these permissions are
          governed by Twitter’s privacy policies and can be managed through your
          Twitter privacy settings). We never post anything to your Twitter
          without your permission.
        </li>
        <li className="li">
          The email address associated with your GitHub account, if you choose
          to sign up using your Github credentials. Learnify will also request
          permission to access additional information (these permissions are
          governed by GitHub’s privacy policies and can be managed through your
          GitHub privacy settings). We never post anything to your GitHub
          without your permission.
        </li>
        <li className="li">
          You also have the option to give us more information if you want to,
          and this may include “User Personal Information.”
        </li>
      </ul>

      <h3 className="header">Information Disclosure</h3>
      <p className="text">
        We do not share, sell, rent, or trade User Personal Information with
        third parties for commercial purposes.
      </p>
      <p className="text">
        We do share certain aggregated, non-personally identifying information
        with others about how our users, collectively, use Learnify. For
        example, we may share information pertaining to the popularity of
        different programming languages for advertising partners.
      </p>
      <p className="text">
        We do host first-party advertising on Learnify. We do not run any code
        from advertisers and all ad images are hosted on managed DEV Community
        servers. For more details, see our section on Advertising Details.
      </p>
      <p className="text">
        We may use User Personal Information with your permission, so we can
        perform services you have authorized.
      </p>
      <p className="text">
        We may share User Personal Information with a limited number of third
        party vendors who process it on our behalf to provide or improve our
        service, and who have agreed to privacy restrictions similar to our own
        Privacy Statement. Our third party vendors are listed below.
      </p>

      <h3 className="header">Advertising Details</h3>
      <p className="text">We target advertisements based solely upon:</p>
      <ul className="ul">
        <li className="li">
          Details of the page where the advertisement is shown, including:
          <ul className="ul">
            <li className="li">
              The name and keywords associated with the page or article being
              viewed
              <ul className="ul">
                <li className="li">
                  We allow advertisers to target ads to a list of keywords
                  advertising.
                </li>
              </ul>
            </li>
          </ul>
        </li>
      </ul>
      <p className="text">We may place ads in:</p>
      <ul className="ul">
        <li className="li">Sidebars</li>
        <li className="li">Below articles</li>
        <li className="li">On search result pages</li>
        <li className="li">On tag pages</li>
      </ul>
      <p className="text">
        All registered members have the ability to disable advertisements —
        where reasonable — through their Settings page. For instance, it’s not
        feasible to disable certain advertisements in the form of recognition
        posts, site-wide contests, dedicated sponsorship page, etc.
      </p>

      <h3 className="header">Third Party Vendors</h3>
      <p className="text">
        <strong>
          We may share your account information with third parties in some
          circumstances, including:
        </strong>{" "}
        (1) with your consent; (2) to a service provider or partner who meets
        our data protection standards; (3) for survey or research purposes,
        after aggregation, anonymization, or pseudonymization; (4) when we have
        a good faith belief it is required by law, such as pursuant to a
        subpoena or other legal process; (5) when we have a good faith belief
        that doing so will help prevent imminent harm to someone.
      </p>
      <p className="text">
        <strong>Data Storage</strong>
        <br />
        Learnify uses third-party vendors and hosting partners for hardware,
        software, networking, storage, and related technology we need to run
        Learnify. By using Learnify Services, you authorize DEV Community to
        transfer, store, and use your information in the United States and any
        other country where we operate. All service providers and third-party
        vendors are required to meet our data protection standards.
      </p>
      <p className="text">
        <strong>Site monitoring</strong>
        <br />
        Learnify uses a variety of third-party services to diagnose errors and
        improve the performance of our site. We aim to minimize the amount of
        personal information shared, but the information may include your IP
        address or other identifying information. All service providers and
        third-party vendors are required to meet our data protection standards.
      </p>
      <p className="text">
        <strong>Payment processing</strong>
        <br />
        Learnify does not process payments directly — we rely on third-party
        services such as Stripe, Shopify, and Paypal to receive payments and
        store any payment information.
      </p>
      <p className="text">
        <strong>Third-Party Embeds</strong>
        <br />
        Some of the content that you see displayed on Learnify is not hosted by
        Learnify. These “embeds” are hosted by a third-party and embedded in
        Learnify. For example: YouTube videos, Codepens, Twitter tweets, or
        GitHub code that appear within a Learnify post. These files send data to
        the hosted site just as if you were visiting that site directly (for
        example, when you load a Learnify post page with a YouTube video
        embedded in it, YouTube receives data about your activity). Learnify
        does not control what data third parties collect in cases like this, or
        what they will do with it. Third-party embeds on Learnify are not
        covered by this privacy policy; they are covered by the privacy policy
        of the third-party service. Be mindful when interacting with these
        services.
      </p>
      <p className="text">
        <strong>Tracking &amp; Cookies</strong>
        <br />
        We use browser cookies and similar technologies to recognize you when
        you return to our Services. Third-party vendors may also use cookies for
        various reasons.
        <br />
        <br />
        Learnify uses a specific cookie in order to facilitate the use of Google
        Universal Analytics for users logged-in to the Applications or the
        Platforms (“Logged-In User). If you are a Logged-In User, DEV Community
        may use your Learnify user ID in combination with Google Universal
        Analytics and Google Analytics to track and analyze the pages of the
        Services you visit. We do this only to better understand how you use the
        Website and the other Services, with a view to offering improvements for
        all Learnify users; and to tailor our business and marketing activities
        accordingly, both generally and specifically to you. Google Analytics
        cookies do not provide Learnify with any Personal Information. You can
        prevent Google Analytics from recognizing you on return visits to this
        site by disabling cookies on your browser.
        <br />
        <br />
        You may opt-out of this feature by installing the Google Analytics
        Opt-out Browser Add-on, by setting your web browser to refuse cookies,
        or by setting your browser to alert you when cookies are being sent. If
        you do so, note that some parts of the Site may not function properly.
      </p>
      <p className="text">
        <strong>Data Security</strong>
        <br />
        We use encryption (HTTPS/TLS) to protect data transmitted to and from
        our site. However, no data transmission over the Internet is 100%
        secure, so we can’t guarantee security. You use the Service at your own
        risk, and you’re responsible for taking reasonable measures to secure
        your account.
      </p>
      <p className="text">
        <strong>Administrative Emails from Learnify</strong>
        <br />
        Sometimes we’ll send you emails about your account, service changes or
        new policies. You can’t opt out of this type of “transactional” email
        (unless you delete your account).
        <br />
        <br />
        When you interact with a transactional email sent from Learnify (such as
        opening an email or clicking on a particular link in an email), we may
        receive information about that interaction.
      </p>
      <p className="text">
        <strong>Non-administrative Emails from Learnify</strong>
        <br />
        Upon creating a Learnify account, you will be opted into the DEV
        Community Newsletter and other non-administrative email. Your email
        address and user profile information may be stored by a third-party
        email provider such as MailChimp or Sendgrid. You can opt out of
        non-administrative emails such as digests, newsletters, and activity
        notifications through your account’s “Settings” page and at the link of
        the footer in any non-administrative email you receive from us.
        <br />
        <br />
        When you interact with a non-administrative email sent from DEV
        Community (such as opening an email or clicking on a particular link in
        an email), we may receive information about that interaction.
      </p>
      <p className="text">
        <strong>Deleting Your Personal Information</strong>
        <br />
        You may request deletion of your personal information and account by
        emailing{" "}
        <a
          href="mailto:yo@dev.to"
          className={"text-accent underline-animation"}
        >
          yo@dev.to
        </a>
        .
        <br />
        <br />
        To protect information from accidental or malicious destruction, we may
        maintain residual copies for a brief time period. But, if you delete
        your account, your information and content will be unrecoverable after
        that time.
      </p>
      <p className="text">
        <strong>Data Portability</strong>
        <br />
        If you would like to request a copy of your user data, please email{" "}
        <a
          href="mailto:yo@dev.to"
          className={"text-accent underline-animation"}
        >
          yo@dev.to
        </a>
        .
      </p>
      <p className="text">
        <strong>Business Transfers</strong>
        <br />
        If we are involved in a merger, acquisition, bankruptcy, reorganization
        or sale of assets such that your information would be transferred or
        become subject to a different privacy policy, we’ll notify you in
        advance of any such change.
      </p>
      <p className="text">
        <strong>Changes to this Policy</strong>
        <br />
        We reserve the right to revise this Privacy Policy at any time. If we
        change this Privacy Policy in the future, we will post the revised
        Privacy Policy and update the “Effective Date,” above, to reflect the
        date of the changes.
      </p>
      <p className="text">
        <strong>Questions</strong>
        <br />
        We welcome feedback about this policy at{" "}
        <a
          href="mailto:yo@dev.to"
          className={"text-accent underline-animation"}
        >
          yo@dev.to
        </a>
        .
      </p>
    </motion.div>
  );
};

export default PrivacyPage;
