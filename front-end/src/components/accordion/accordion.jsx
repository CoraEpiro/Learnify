import PropTypes from "prop-types";
import { useState } from "react";
import {
  Accordion,
  AccordionHeader,
  AccordionBody,
} from "@material-tailwind/react";

const AccordionCollapse = ({ title, children }) => {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <div className="">
      <Accordion open={isOpen}>
        <AccordionHeader
          onClick={() => {
            setIsOpen(!isOpen);
          }}
        >
          {title}
        </AccordionHeader>
        <AccordionBody>{children}</AccordionBody>
      </Accordion>
    </div>
  );
};

AccordionCollapse.propTypes = {
  title: PropTypes.string,
  children: PropTypes.any,
};

export default AccordionCollapse;
