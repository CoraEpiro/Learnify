import Yup from "../validation-localization.js";
export const ResetPasswordNewPasswordFormSchema = Yup.object().shape({
  password: Yup.string()
    .required()
    .matches(
      /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#\$%^&*()\-_=+{};:'",<.>/?\\\[\]|`~])[A-Za-z\d!@#\$%^&*()\-_=+{};:'",<.>/?\\\[\]|`~]{8,}$/
    ),
});
