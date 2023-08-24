function parseData(data) {
  const formData = new FormData();

  for (let [key, value] of Object.entries(data)) {
    formData.append(key, value);
  }
  return formData;
}

function request(url, data = false, method = "GET", type = "JSON") {
  return new Promise(async (resolve, reject) => {
    const options = { method, headers: {} };

    if (data && method === "POST") {
      options.body = type === "JSON" ? JSON.stringify(data) : parseData(data);
      options.headers["Content-Type"] =
        type === "JSON" ? "application/json" : "multipart/form-data";

      // Token Authentication
      const token =
        localStorage.getItem("token") ?? sessionStorage.getItem("token");

      if (token) {
        options.headers["Authorization"] = `Bearer ${token}`;
      }
    }

    const response = await fetch(import.meta.env.VITE_API_URL + url, options);

    let result = "";

    try {
      const contentType = response.headers.get("Content-Type");
      if (contentType.includes("text/plain")) {
        result = await response.text();
      } else if (contentType.includes("application/json")) {
        result = await response.json();
      }
    } catch (e) {
      result = " ";
    }

    if (response.ok) {
      resolve(result);
    } else {
      reject({ status: response.status, message: result });
    }
  });
}

export const post = (url, data) => request(url, data, "POST");
export const get = (url) => request(url);
