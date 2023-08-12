import * as Yup from "yup";

Yup.setLocale({
  string: {
    matches: "Please write the password according to the requirements.",
  },
});

export default Yup;
