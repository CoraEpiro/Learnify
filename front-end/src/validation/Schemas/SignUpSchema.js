import Yup from "../validation-localization.js";
export const SignUpSchema = Yup.object().shape({
  email: Yup.string().required().email(),
  password: Yup.string()
    .required()
    .matches(
      /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#\$%^&*()\-_=+{};:'",<.>/?\\\[\]|`~])[A-Za-z\d!@#\$%^&*()\-_=+{};:'",<.>/?\\\[\]|`~]{8,}$/
    ),
});
