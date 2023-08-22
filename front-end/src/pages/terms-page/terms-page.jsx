import { motion } from "framer-motion";
import { Link } from "react-router-dom";

const TermsPage = () => {
  document.title = "Terms of Use for Learnify";

  return (
    <motion.div
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      className={
        "mt-3 px-16 py-8 mx-28 bg-white rounded-lg flex flex-col gap-4"
      }
    >
      <h1 className={"primary-header"}>Web Site Terms and Conditions of Use</h1>
      <h3 className="header" id="terms-text">
        1. Terms
      </h3>

      <p className="text">
        By accessing this web site, you are agreeing to be bound by these web
        site Terms and Conditions of Use, our{"  "}
        <Link to="/privacy" className="underline-animation text-accent">
          Privacy Policy
        </Link>
        , all applicable laws and regulations, and agree that you are
        responsible for compliance with any applicable local laws. If you do not
        agree with any of these terms, you are prohibited from using or
        accessing this site. The materials contained in this web site are
        protected by applicable copyright and trade mark law.
      </p>

      <h3 className="header" id="use-licence">
        2. Use License
      </h3>

      <ol className={"ol ls-alpha"}>
        <li className="li">
          Permission is granted to temporarily download one copy of the
          materials (information or software) on Learnify&apos;s web site for
          personal, non-commercial transitory viewing only. This is the grant of
          a license, not a transfer of title, and under this license you may
          not:
          <ol type="i" className="ol ls-roman">
            <li className="li">modify or copy the materials;</li>
            <li className="li">
              use the materials for any commercial purpose, or for any public
              display (commercial or non-commercial);
            </li>
            <li className="li">
              attempt to decompile or reverse engineer any software contained on
              Learnify&apos;s web site;
            </li>
            <li className="li">
              remove any copyright or other proprietary notations from the
              materials; or
            </li>
            <li className="li">
              transfer the materials to another person or &quot;mirror&quot; the
              materials on any other server.
            </li>
          </ol>
        </li>
        <li className="li">
          This license shall automatically terminate if you violate any of these
          restrictions and may be terminated by Learnify at any time. Upon
          terminating your viewing of these materials or upon the termination of
          this license, you must destroy any downloaded materials in your
          possession whether in electronic or printed format.
        </li>
      </ol>

      <h3 className="header" id="disclaimer">
        3. Disclaimer
      </h3>

      <ol className={"ol ls-alpha"}>
        <li className="li">
          The materials on Learnify&apos;s web site are provided &quot;as
          is&quot;. DEV Community makes no warranties, expressed or implied, and
          hereby disclaims and negates all other warranties, including without
          limitation, implied warranties or conditions of merchantability,
          fitness for a particular purpose, or non-infringement of intellectual
          property or other violation of rights. Further, Learnify does not
          warrant or make any representations concerning the accuracy, likely
          results, or reliability of the use of the materials on its Internet
          web site or otherwise relating to such materials or on any sites
          linked to this site.
        </li>
      </ol>

      <h3 className="header" id="limitations">
        4. Limitations
      </h3>

      <p className="text">
        In no event shall Learnify or its suppliers be liable for any damages
        (including, without limitation, damages for loss of data or profit, or
        due to business interruption,) arising out of the use or inability to
        use the materials on Learnify&apos;s Internet site, even if Learnify or
        an authorized representative has been notified orally or in writing of
        the possibility of such damage. Because some jurisdictions do not allow
        limitations on implied warranties, or limitations of liability for
        consequential or incidental damages, these limitations may not apply to
        you.
      </p>

      <h3 className="header" id="revisions-and-errata">
        5. Revisions and Errata
      </h3>

      <p className="text">
        The materials appearing on Learnify&apos;s web site could include
        technical, typographical, or photographic errors. Learnify does not
        warrant that any of the materials on its web site are accurate,
        complete, or current. Learnify may make changes to the materials
        contained on its web site at any time without notice. Learnify does not,
        however, make any commitment to update the materials.
      </p>

      <h3 className="header" id="links">
        6. Links
      </h3>

      <p className="text">
        Learnify has not reviewed all of the sites linked to its Internet web
        site and is not responsible for the contents of any such linked site.
        The inclusion of any link does not imply endorsement by DEV Community of
        the site. Use of any such linked web site is at the user&apos;s own
        risk.
      </p>

      <h3 className="header" id="copyright-takedown">
        7. Copyright / Takedown
      </h3>

      <p className="text">
        Users agree and certify that they have rights to share all content that
        they post on Learnify — including, but not limited to, information
        posted in articles, discussions, and comments. This rule applies to
        prose, code snippets, collections of links, etc. Regardless of citation,
        users may not post copy and pasted content that does not belong to them.
        Users assume all risk for the content they post, including someone
        else&apos;s reliance on its accuracy, claims relating to intellectual
        property, or other legal rights. If you believe that a user has
        plagiarized content, misrepresented their identity, misappropriated
        work, or otherwise run afoul of DMCA regulations, please email{" "}
        <a href="mailto:yo@dev.to" className="underline-animation text-accent">
          yo@dev.to
        </a>
        . Learnify may remove any content users post for any reason.
      </p>

      <h3 className="header" id="site-terms-of-use-modifications">
        8. Site Terms of Use Modifications
      </h3>

      <p className="text">
        Learnify may revise these terms of use for its web site at any time
        without notice. By using this web site you are agreeing to be bound by
        the then current version of these Terms and Conditions of Use.
      </p>

      <h3 className="header" id="dev-trademarks-and-logo-policy">
        9. Learnify Trademarks and Logos Policy
      </h3>

      <p className="text">
        All uses of the Learnify logo, Learnify badges, brand slogans,
        iconography, and the like, may only be used with express permission from
        Learnify. Learnify reserves all rights, even if certain assets are
        included in Learnify open source projects. Please contact{" "}
        <a href="mailto:yo@dev.to" className="underline-animation text-accent">
          yo@dev.to
        </a>{" "}
        with any questions or to request permission.
      </p>

      <h3 className="header" id="reserved-names">
        10. Reserved Names
      </h3>

      <p className="text">
        Learnify has the right to maintain a list of reserved names which will
        not be made publicly available. These reserved names may be set aside
        for purposes of proactive trademark protection, avoiding user confusion,
        security measures, or any other reason (or no reason).
      </p>

      <p className="text">
        Additionally, Learnify reserves the right to change any already-claimed
        name at its sole discretion. In such cases, DEV Community will make
        reasonable effort to find a suitable alternative and assist with any
        transition-related concerns.
      </p>

      <h3 className="header" id="content-policy">
        11. Content Policy
      </h3>

      <p className="text">
        The following policy applies to comments, articles, and all other works
        shared on the Learnify platform:
      </p>
      <ul className="ul">
        <li className="li">
          Users must make a good-faith effort to share content that is on-topic,
          of high-quality, and is not designed primarily for the purposes of
          promotion or creating backlinks.
        </li>
        <li className="li">
          Posts must contain substantial content — they may not merely reference
          an external link that contains the full post.
        </li>
        <li className="li">
          If a post contains affiliate links, that fact must be clearly
          disclosed. For instance, with language such as: “This post includes
          affiliate links; I may receive compensation if you purchase products
          or services from the different links provided in this article.”
        </li>
      </ul>

      <p className="text"></p>

      <p className="text">
        Learnify reserves the right to remove any content that it deems to be in
        violation of this policy at its sole discretion. Additionally, DEV
        Community reserves the right to restrict any user’s ability to
        participate on the platform at its sole discretion.
      </p>

      <h3 className="header" id="governing-law">
        12. Governing Law
      </h3>

      <p className="text">
        Any claim relating to Learnify&apos;s web site shall be governed by the
        laws of the State of New York without regard to its conflict of law
        provisions.
      </p>

      <p className="text">
        General Terms and Conditions applicable to Use of a Web Site.
      </p>
    </motion.div>
  );
};

export default TermsPage;
