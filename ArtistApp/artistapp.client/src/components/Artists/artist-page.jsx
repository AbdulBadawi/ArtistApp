import { useEffect, useState } from "react";
import { Button, Table } from "react-bootstrap";
import { useNavigate } from "react-router";
import DeleteConfirmationModal from "../../shared/delete-confirmation";
import { requestUrl } from "../../utils/utilServices";

const ArtistPage = () => {
  const navigate = useNavigate();
  const [artist, setArtist] = useState();
  const [showConfirmation, setShowConfirmation] = useState(false);

  useEffect(() => {
    artistList();
  }, []);
  const handleDelete = (id) => {
    fetch(`${requestUrl}Artist/DeleteArtist?id=${id}`, {
      method: "DELETE",
    })
      .then(() => {
        var res = artist.filter((x) => x.id !== id);
        setArtist(res);
        setShowConfirmation(false);
      })
      .catch((error) => {
        console.error("Error :", error);
      });
  };

  const artistList = () => {
    fetch(`${requestUrl}Artist/GetArtistsWithAlbums`, {
      method: "GET",
    })
      .then((res) => res.json())
      .then((data) => {
        setArtist(data);
      })
      .catch((error) => {
        console.error("Error :", error);
      });
  };
  return (
    <div className="row">
      <div className="mb-2">
        <b style={{ fontSize: "20px" }}>Artists </b>
        <Button
          variant="primary"
          size="sm"
          className="float-end"
          onClick={() => navigate("add-artist")}
        >
          Add
        </Button>
      </div>
      <div>
        <Table striped bordered hover responsive>
          <thead>
            <tr>
              <th>#</th>
              <th>Name</th>
              <th>Description</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            {artist?.length > 0 ? (
              artist.map((item, index) => {
                return (
                  // eslint-disable-next-line react/jsx-key
                  <tr>
                    <td key={index}>{index + 1}</td>
                    <td>{item?.name}</td>
                    <td>
                      {item?.description.length > 100
                        ? item?.description.substring(0, 100) + "...."
                        : item?.description}
                    </td>
                    <td>
                      <Button
                        variant="info"
                        size="sm"
                        onClick={() => navigate(`edit-artist/${item.id}`)}
                      >
                        Edit
                      </Button>{" "}
                      <Button
                        variant="danger"
                        size="sm"
                        onClick={() => setShowConfirmation(true)}
                      >
                        Delete
                      </Button>{" "}
                      <Button
                        variant="primary"
                        size="sm"
                        onClick={() => navigate(`view-artist/${item.id}`)}
                      >
                        View
                      </Button>
                      <DeleteConfirmationModal
                        show={showConfirmation}
                        onHide={() => setShowConfirmation(false)}
                        onConfirm={() => handleDelete(item.id)}
                      />
                    </td>
                  </tr>
                );
              })
            ) : (
              <tr>
                <td colSpan={7} style={{ textAlign: "center" }}>
                  No Data Found.
                </td>
              </tr>
            )}
          </tbody>
        </Table>
      </div>
    </div>
  );
};
export default ArtistPage;
